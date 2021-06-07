using Microsoft.AspNetCore.Components;
using System;

namespace BlazorWasmPostRenderInitialization.Pages
{
    public class CustomComponentBase : ComponentBase
    {
        [Inject] private FirstRenderStateContainer FirstRenderStateContainer { get; init; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Console.WriteLine("Index: First Render");
                FirstRenderStateContainer.SetRendered();
            }
        }
    }
}
