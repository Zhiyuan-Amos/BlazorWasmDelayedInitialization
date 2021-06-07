using System;

namespace BlazorWasmPostRenderInitialization
{
    public class FirstRenderStateContainer
    {
        public event Action OnFirstRender;
        private bool _isFirstRendered;

        public void SetRendered()
        {
            if (_isFirstRendered) return;

            Console.WriteLine("FirstRenderStateContainer: Invoking methods in delegate OnFirstRender");
            _isFirstRendered = true;
            OnFirstRender?.Invoke();
        }
    }
}
