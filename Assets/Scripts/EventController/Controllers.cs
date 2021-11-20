using System.Collections.Generic;

namespace DefaultNamespace
{
    public class Controllers : IInitialsation, IExecute, ILateExecute, ICleanup, IFixedExecute
    {
        private readonly List<IInitialsation> _initControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ILateExecute> _lateControllers;
        private readonly List<ICleanup> _cleanupControllers;
        private readonly List<IFixedExecute> _fixedControllers;
       

        internal Controllers()
        {
            _initControllers = new List<IInitialsation>();
            _executeControllers = new List<IExecute>();
            _lateControllers = new List<ILateExecute>();
            _cleanupControllers = new List<ICleanup>();
            _fixedControllers = new List<IFixedExecute>();
          
        }

        internal Controllers Add(IController controller)
        {
            if (controller is IInitialsation initializeController)
            {
                _initControllers.Add(initializeController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            if (controller is ILateExecute lateExecuteController)
            {
                _lateControllers.Add(lateExecuteController);
            }

            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }

            if (controller is IFixedExecute fixedExecute)
            {
                _fixedControllers.Add(fixedExecute);
            }
            
            return this;
        }


        public void Initialization()
        {
            _initControllers?.ForEach(x => x.Initialization());
        }

        public void Execute(float deltaTime)
        {
            _executeControllers?.ForEach(x => x.Execute(deltaTime));
        }

        public void LateExecute(float deltaTime)
        {
            _lateControllers?.ForEach(x => x.LateExecute(deltaTime));
        }

        public void Cleanup()
        {
            _cleanupControllers?.ForEach(x => x.Cleanup());
        }

        public void FixedExecute(float deltaTime)
        {
            _fixedControllers?.ForEach(x => x.FixedExecute(deltaTime));
        }
    }

    
}