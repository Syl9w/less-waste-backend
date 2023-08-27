using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.WasteGoals
{
    public class WasteGoalDto
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public float TargetPlastic { get; set; }
        public float TargetPaper { get; set; }
        public float TargetWater { get; set; }
        public float TargetFood { get; set; }
        public float TargetFuel { get; set; }

        public float ProgressPlastic { get; set; }
        public float ProgressPaper { get; set; }
        public float ProgressWater { get; set; }
        public float ProgressFood { get; set; }
        public float ProgressFuel { get; set; }
    }
}