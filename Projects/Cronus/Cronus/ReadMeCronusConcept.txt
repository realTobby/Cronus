Hello!

Cronus is a ZPL Editor.

It aims to be an editor that makes the art of creating ZPL Templates braindead simple.

With a toolbox for "every" ZPL Element possible, easy drag and shape.
No ZPL knowledge "needed"

What else?

Cronus uses a Workspace Folder thats locally on your Computer.
This folder is saved in the registry under CURRENTUSER/SOFTWARE/CRONUS/WORKSPACEPATH

Every Project has its own directory.
The directory name is the Project Name of the Template.

Inside of that folder, you have project.ini that holds the following informations:
	- ProjectName (matches with the directory)
	- Author
	- Description
	- CreateDate
	- ChangeDate
	- List of (MetaFiles => only loaded when inside the Project)
(Model => ProjectModel)

Also inside that folder there is a preview and the zpl code:
	- Preview (as PNG or JPG or GIF)
	- ProjectName.zpl (zpl code)
(Model => ProjectMetaFile)



