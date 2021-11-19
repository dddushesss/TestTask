using System.ComponentModel.Design;

namespace DefaultNamespace
{
    public interface IExecute : IController
    {
        void Execute(float deltaTime);
    }
}