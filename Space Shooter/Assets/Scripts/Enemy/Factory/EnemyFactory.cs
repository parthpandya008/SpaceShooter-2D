using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public class EnemyFactory
{
    private Dictionary<EnemyType, Type> enemyByType;

    public EnemyFactory()
    {
        var enemyType = Assembly.GetAssembly(typeof(EnemyType)).GetTypes().
            Where
            (
                mytype => mytype.IsClass && !mytype.IsAbstract && mytype.IsSubclassOf(typeof(BaseEnemy))
            );
        enemyByType = new Dictionary<EnemyType, Type>();
        foreach (var type in enemyType)
        {
            var temp = Activator.CreateInstance(type) as BaseEnemy;
            enemyByType.Add(temp.Type, type);
        }
    }

    public BaseEnemy GetEnemy(EnemyType enemyType)
    {
        if (enemyByType.ContainsKey(enemyType))
        {
            Type type = enemyByType[enemyType];
            BaseEnemy enemy = (BaseEnemy)Activator.CreateInstance(type);
            return enemy;
        }
        return null;
    }

    internal IEnumerable<EnemyType> GetEnemyNames()
    {
        return enemyByType.Keys;
    }
    

}
