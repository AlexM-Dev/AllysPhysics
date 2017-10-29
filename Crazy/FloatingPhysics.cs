using PhysicsCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AllysPhysics {
    public class FloatingPhysics : PhysicsSet {
        private ReversePhysics reverse = new ReversePhysics();
        public string Name { get; set; }
        public string Description { get; set; }
        public FloatingPhysics() {
            Name = "Floating Physics";
            Description = "Dots just \"float around\".";
        }
        public void ApplyPhysics(Dot d1, Dot d2, Config cfg) {
            if (cfg.r.Next(2) == 0) {
                reverse.ApplyPhysics(d1, d2, cfg);
            } else {
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
                d1.p = new Point(d1.p.X + moveX, d1.p.Y + moveY);
            }
        }
        public Dot GetDot(Dot d1, Config cfg) {
            return cfg.Particles[cfg.r.Next(cfg.Particles.Count - 1)];
        }
    }
}
