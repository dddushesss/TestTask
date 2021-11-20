namespace DefaultNamespace
{
    public interface ILateExecute : IController
    {
        void LateExecute(float deltaTime);
    }
    
}