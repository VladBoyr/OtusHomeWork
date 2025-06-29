namespace GRASP
{
    public abstract class Unit
    {
        public float Hp;
        public abstract void Move();
    }
    
    public sealed class Knight : Unit
    {
        public void Hit(Unit target)
        {
            
        }

        public override void Move()
        {
            
        }
    }
    
    public sealed class Archer : Unit
    {
        public void Shoot(Unit target)
        {
            
        }

        public override void Move()
        {
            
        }
    }

    public sealed class Mage : Unit
    {
        public void SpellCast(Unit target)
        {
            
        }

        public override void Move()
        {
            
        }
    }
    
    
    public sealed class UnitAttacker
    {
        public void Attack(Unit[] units, Unit target)
        {
            foreach (var unit in units)
            {
                if (unit is Knight knight)
                {
                    knight.Hit(target);
                }
                else if (unit is Archer archer)
                {
                    archer.Shoot(target);
                }
                else if (unit is Mage mage)
                {
                    mage.SpellCast(target);
                }
            }

            for (var index = 0; index < units.Length; index++)
            {
                Unit unit = units[index];
                unit.Move();
            }
        }
    }
}
