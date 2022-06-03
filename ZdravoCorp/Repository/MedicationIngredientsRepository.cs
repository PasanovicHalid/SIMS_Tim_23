using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoCorp.Exceptions;

namespace ZdravoCorp.Repository
{
    public class MedicationIngredientsRepository : Repository<MedicineIngredient>
    {
        private static MedicationIngredientsRepository instance = null;
        private HashSet<string> ingredientNameMap = new HashSet<string>();
        public MedicationIngredientsRepository()
        {
            dbPath = "..\\..\\Data\\ingredientsDB.csv";
            InstantiateIDSet(GetAll());
        }

        public override void Create(MedicineIngredient element)
        {
            lock (key)
            {
                CheckIfNameExists(element.Name);
                element.Id = GenerateID();
                AppendToDB(element);
                ingredientNameMap.Add(element.Name);
                idMap.Add(element.Id);
            }
        }

        public override void Delete(int id)
        {
            lock (key)
            {
                CheckIfIngredientExists(id);
                List<MedicineIngredient> ingredients = GetAll();
                DeleteIngredientByID(ingredients, id);
                SaveChanges(ingredients);
            }
        }

        public override MedicineIngredient Read(int id)
        {
            lock (key)
            {
                CheckIfIngredientExists(id);
                return FindIngredientByID(GetAll(), id);
            }
        }

        public override void Update(MedicineIngredient element)
        {
            lock (key)
            {
                CheckIfIngredientExists(element.Id);
                List<MedicineIngredient> ingredients = GetAll();
                SwapIngredientsByID(ingredients, element);
                SaveChanges(ingredients);
            }
        }

        protected override void InstantiateIDSet(List<MedicineIngredient> elements)
        {
            foreach (MedicineIngredient element in elements)
            {
                idMap.Add(element.Id);
                ingredientNameMap.Add(element.Name);
            }
        }

        private void CheckIfNameExists(string name)
        {
            if (ingredientNameMap.Contains(name))
                throw new LocalisedException("IngredientDoesExist");
        }

        private void CheckIfIngredientExists(int id)
        {
            if(!idMap.Contains(id))
                throw new LocalisedException("IngredientDoesntExist");
        }

        private void DeleteIngredientByID(List<MedicineIngredient> ingredients, int id)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients[i].Id == id)
                {
                    ingredients.RemoveAt(i);
                    return;
                }
            }
            throw new LocalisedException("IngredientDoesntExist");
        }

        private void SwapIngredientsByID(List<MedicineIngredient> ingredients, MedicineIngredient ingredient)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients[i].Id == ingredient.Id)
                {
                    ingredients[i] = ingredient;
                    return;
                }
            }
            throw new LocalisedException("IngredientDoesntExist");
        }

        private MedicineIngredient FindIngredientByID(List<MedicineIngredient> ingredients, int id)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients[i].Id == id)
                {
                    return ingredients[i];
                }
            }
            throw new LocalisedException("IngredientDoesntExist");
        }

        public static MedicationIngredientsRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (key)
                    {
                        if (instance == null)
                        {
                            instance = new MedicationIngredientsRepository();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
