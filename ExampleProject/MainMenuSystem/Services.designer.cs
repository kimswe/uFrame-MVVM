// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace uFrame.ExampleProject {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UniRx;
    using uFrame.Kernel;
    using uFrame.ExampleProject;
    using uFrame.MVVM;
    using uFrame.IOC;
    using UnityEngine;
    
    
    public class MainMenuServiceBase : uFrame.Kernel.SystemServiceMonoBehavior {
        
        /// <summary>
        /// This method is invoked whenever the kernel is loading.
        /// Since the kernel lives throughout the entire lifecycle of the game, this will only be invoked once.
        /// </summary>
        public override void Setup() {
            base.Setup();
            this.OnEvent<RequestMainMenuScreenCommand>().Subscribe(this.RequestMainMenuScreenCommandHandler);
        }
        
        /// <summary>
        // This method is executed when using this.Publish(new RequestMainMenuScreenCommand())
        /// </summary>
        public virtual void RequestMainMenuScreenCommandHandler(RequestMainMenuScreenCommand data) {
            // Process the commands information.  Also, you can publish new events by using the line below.
            // this.Publish(new AnotherEvent())
        }
    }
}
