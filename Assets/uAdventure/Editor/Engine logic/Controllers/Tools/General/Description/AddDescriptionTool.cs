﻿using UnityEngine;
using System.Collections;

using uAdventure.Core;

namespace uAdventure.Editor
{
    public class AddDescriptionTool : Tool
    {

        private DescriptionsController descriptionsController;

        private DescriptionController descriptionController;

        private Description description;


        public AddDescriptionTool(DescriptionsController descriptionsController)
        {

            this.descriptionsController = descriptionsController;

        }



        public override bool canRedo()
        {

            return true;
        }


        public override bool canUndo()
        {

            return true;
        }


        public override bool combine(Tool other)
        {

            return false;
        }


        public override bool doTool()
        {

            description = new Description();
            descriptionsController.addDescription(description);
            descriptionController = new DescriptionController(description);
            descriptionsController.addDescriptionController(descriptionController);

            return true;
        }


        public override bool redoTool()
        {

            descriptionsController.addDescription(description);
            descriptionsController.addDescriptionController(descriptionController);
            descriptionsController.setSelectedDescription(descriptionsController.getDescriptionCount() - 1);
            Controller.Instance.updatePanel();
            return false;
        }


        public override bool undoTool()
        {

            bool undone = descriptionsController.removeDescription(description) && descriptionsController.removeDescriptionController(descriptionController);
            if (undone)
            {
                descriptionsController.setSelectedDescription(descriptionsController.getDescriptionCount() - 1);
                Controller.Instance.updatePanel();
                return true;
            }
            return false;
        }
    }
}