using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    /// <summary>
    /// A base farm animal class.
    /// </summary>
    /// abstract means i can't say new FarmAnimal(); 
    public abstract class FarmAnimal : ISingable //all farm animals are Singable but not all farm animals are sellable so we put the interface on teh ones that are
    {       
        /// <summary>
        /// The farm animal's name.
        /// </summary>
        public string Name { get; }

        private bool isSleeping = false;
        public void GoToSleep()
        {
            isSleeping = true;
        }
        public void WakeUp()
        {
            isSleeping = false;
        }

        /// <summary>
        /// Creates a new farm animal.
        /// </summary>
        /// <param name="name">The name which the animal goes by.</param>
        public FarmAnimal(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// The noise made when the farm animal makes a sound.
        /// </summary>
        /// <returns></returns>
        public string MakeSoundOnce()
        {
            if (isSleeping)
                return "zzzzzz";
            else
                return MakeAwakeSoundOnce();
        }

        /// <summary>
        /// The noise made when the farm animal makes its sound twice.
        /// </summary>
        /// <returns></returns>
        public string MakeSoundTwice() //removing the virtual keyword prevents subclasses from overriding
        {
            if (isSleeping)
                return "zzzzzz  zzzzzzz";
            else
                return MakeAwakeSoundTwice();
        }

        public virtual string MakeAwakeSoundOnce()
        { 
            return ""; 
        }

        public virtual string MakeAwakeSoundTwice()
        {
            return "";
        }

        //force subclasses to have an eat method
        public abstract string eat();
        /*
        public string Eat()
        {
            return "mmmm";
        }
        */

        /*
         * abstract => means all children/subclasses MUST override
         * virtual => means all children/subclasses MAY override
         * neither keyword => means all children/subclasses MAY NOT override
         */
}
}
