/*
 * EXCEEDS REQUIREMENTS:
 * I exceeded the project requirements by adding a **Gamified Leveling System** and **Milestone Rewards.
 * 1. **Leveling System:** Every 500 points, the user "levels up" and receives a congratulatory message.
 * 2. **Milestone Rewards:** Every 1000 points, the user earns a special badge (Bronze, Silver, Gold).
 * 3. **Visual Feedback:** Used console colors to make the experience more engaging and fun. 
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
