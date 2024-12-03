using System.Collections.Generic;
using Core.Scripts.Services.Level.Level;

namespace Core.Scripts.Services.Level.Provider
{
    public interface ILevelProvider
    {
        public int Amount { get; }  
        public IEnumerable<LevelComponentBase> Levels { get; }
    }
}