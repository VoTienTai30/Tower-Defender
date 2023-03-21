using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class DataLoad
    {
        public static bool isContinue = false;
        public static int health;
        public static int money;
        public static List<string> towers = new List<string>();
        public static List<string> enemies = new List<string>();
        public static int spawnerTime;
        public static int percentRandomBoss;
        public static int countTimeSpawn;
        public static float enemySpawnRateIncrease;
        public static int numberEnemySpawn;
        public static float distanceBetweenObjects;
    }
}
