using PhysicsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AllysPhysics {
    class AgingPhysics : Default {
        public Dictionary<string, int> ages = new Dictionary<string, int>();
        public AgingPhysics() {
            Name = "Aging Physics";
            Description = "Particles that grow and die as they age. Based on DEFAULT.";
        }
        public override void ApplyPhysics(Dot d1, Dot d2, Config cfg) {
            base.ApplyPhysics(d1, d2, cfg);
            if (!ages.ContainsKey(d1.UUID)) {
                ages.Add(d1.UUID, -1);
            }
            if (cfg.r.Next(10) == 0) {
                ages[d1.UUID] += 1; // Increase age. 
                int age = ages[d1.UUID];
                if (age < 20) {
                    d1.s = new Size(d1.s.Width + (ages[d1.UUID]),
                        d1.s.Height + (ages[d1.UUID]));
                } else {
                    d1.UUID = null;
                }
            }
            // Warning! Large dictionary size is a cause of a memory leak.
            // The dictionary must be enumerated through in order to check
            // that certain dots STILL exist. 
            // Enumerate through cfg.Particles -> create a new Dictionary
            // with preserved sizes. Delete the old dictionary. If the dot
            // does not exist within the existing dictionary, create an entry.
        }
    }
}
