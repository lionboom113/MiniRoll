using Microsoft.Practices.Unity;
using System.Linq;
using Template.Domain.Orm;
using Template.Domain.Definitions;
using Template.Domain.Exceptions;
using Template.Domain.Models;
using System.Collections.Generic;
using Template.Domain.Entities;
using System;

namespace Template.Domain.UseCases
{
    /// <summary>
    /// <para>TodoItemの管理を表すユースケース.</para>
    /// </summary>
    public class RollManagement
    {
        public static List<Roll> rolls;

        public RollManagement()
        {
            if (rolls == null)
            {
                rolls = new List<Roll>();
            }
        }
        public Roll add(Roll roll)
        {
            rolls.Add(roll);
            return roll;
        }
        public Roll update(Roll roll)
        {
            rolls.Remove(roll);
            rolls.Add(roll);
            return roll;
        }
        public Roll get(Guid id)
        {
            foreach (var roll in rolls)
            {
                if (roll.Id.Equals(id))
                {
                    return roll;
                }
            }
            return null;
        }
        
    }
}
