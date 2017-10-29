using PhysicsCore;
using System.Drawing;
using System;

namespace AllysPhysics {
    public class TestPhysics : PhysicsSet {
        public string Name { get; set; }
        public string Description { get; set; }
        public TestPhysics() {
            Name = "Test Physics";
            Description = "A custom, community-provided PhysicsSet.";
        }
        public void ApplyPhysics(Dot d1, Dot d2, Config cfg) {
            // d1 refers to the dot being modified, d2 as a secondary dot (for comparison).
            // cfg is the program's current instance of Config and contains exposed, global
            // variables for use in PhysicsSets.

            d1.p.X += cfg.MoveValue; // Moves the point to the right by what the particle speed is.

            // The following sets the dot's colour to random:
            Random r = cfg.r;
            d1.c = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
        }
        public Dot GetDot(Dot d1, Config cfg) {
            // Decides what dot should be used for `d2` in ApplyPhysics. 
            // In this case, it's a random particle. (r is an instance of Random).
            return cfg.Particles[cfg.r.Next(cfg.Particles.Count - 1)];
        }
    }
}
