using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoCorp.View.ViewModel
{
    public class RoomVO
    {
        private int identifier;
        private String designationCode;
        private float surfaceArea;
        private bool renovating;
        private DateTime renovatedUntil;
        private String type;

        public RoomVO()
        {
        }

        public RoomVO(int identifier, string designationCode, float surfaceArea, bool renovating, DateTime renovatedUntil, string type)
        {
            this.Identifier = identifier;
            this.DesignationCode = designationCode;
            this.SurfaceArea = surfaceArea;
            this.Renovating = renovating;
            this.RenovatedUntil = renovatedUntil;
            this.Type = type;
        }

        public int Identifier { get => identifier; set => identifier = value; }
        public string DesignationCode { get => designationCode; set => designationCode = value; }
        public float SurfaceArea { get => surfaceArea; set => surfaceArea = value; }
        public bool Renovating { get => renovating; set => renovating = value; }
        public DateTime RenovatedUntil { get => renovatedUntil; set => renovatedUntil = value; }
        public string Type { get => type; set => type = value; }
    }
}
