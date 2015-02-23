using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oEngine.Commands
{
    public class Command
    {
        /// <summary>
        /// Gets or sets the method to execute
        /// </summary>
        public Action Execute { get; set; }

        /// <summary>
        /// Gets or sets the method to undo
        /// </summary>
        public Action UnExecute { get; set; }

        /// <summary>
        /// Gets or sets the method to check for a possible execute
        /// </summary>
        public Func<bool> CanExecute { get; set; }

        /// <summary>
        /// Gets or sets the name of the command
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the explanation of what the command should do
        /// Used for logging
        /// </summary>
        public string Description { get; set; }


    }
}
