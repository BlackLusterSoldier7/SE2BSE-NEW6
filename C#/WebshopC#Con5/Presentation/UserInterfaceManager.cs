using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class UserInterfaceManager
    {


        private readonly MenuDisplayHandler menuDisplayHandler;
        private readonly UserInputHandler userInputHandler;
        private readonly ProductDisplayHandler productDisplayHandler; 


        public UserInterfaceManager(
            MenuDisplayHandler menuDisplayHandler, 
            UserInputHandler userInputHandler, 
            ProductDisplayHandler productDisplayHandler)
        {

            this.menuDisplayHandler = menuDisplayHandler;
            this.userInputHandler = userInputHandler;
            this.productDisplayHandler = productDisplayHandler;




        }





        public void RunShop()
        {





        }







    }
}
