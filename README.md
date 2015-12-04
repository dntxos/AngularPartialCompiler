# AngularPartialCompiler
AngularPartialCompiler compiles your Html partials into a typescript file

USAGE:<BR>
	APC.EXE *[OUTPUT] [PATH] [FILTER] [CLASSNAME] [MODULENAME]<BR>
	*Mandatory

	[OUTPUT] - Filename of generated typescript file
	[PATH] - Directory path that contains your HTML partial files.
	[FILTER] - Filter files with a pattern. (Default:"view*.html").
	[CLASSNAME] - Name of generated typescript class.
	[MODULENAME] - Typescript module name.
	
---
In VisualStudio you can set APC to compile your partials at every build.<Br>
Set on build-events>pre-build: apc.exe $(ProjectDir)\output.ts $(ProjectDir)\

<a href='https://github.com/dntxos/AngularPartialCompiler/raw/master/AngularPartialCompiler/AngularPartialCompiler/setup/apc-setup.exe'>Download installer</a>
