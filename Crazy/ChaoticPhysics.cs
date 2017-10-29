using PhysicsCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AllysPhysics {
    class ChaoticPhysics : PhysicsSet {
        public string Name { get; set; }
        public string Description { get; set; }
        public ChaoticPhysics() {
            Name = "Chaotic Physics";
            Description = "Physics that don't always set both x+y - based on DEFAULT.";
        }
        public void ApplyPhysics(Dot d1, Dot d2, Config cfg) {
            if (d1 == null || d2 == null) { return; }
            int moveX = 0; int moveY = 0;
            if (d2.p.X < d1.p.X) {
                moveX = cfg.MoveValue;
            } else if (d2.p.X > d1.p.X) {
                moveX = -1 * cfg.MoveValue;
            }
            
            if (d2.p.Y < d1.p.Y) {
                moveY = cfg.MoveValue;
            } else if (d2.p.Y > d1.p.Y) {
                moveY = -1 * cfg.MoveValue;
            }
            int i = cfg.r.Next(5); // 0, 1, 2, 3, 4
            if (i < 2) {
                d1.p.X += moveX;

            } else if (i >= 2 && i < 4) {
                d1.p.Y += moveY;

            } else {
                d1.p.X += moveX;
                d1.p.Y += moveY;

            }  
        }
        public Dot GetDot(Dot d1, Config cfg) {
            return cfg.Particles[cfg.r.Next(cfg.Particles.Count - 1)];
        }
    }
}
