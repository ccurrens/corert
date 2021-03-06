_Please ensure that [pre-requisites](prerequisites-for-building.md) are installed for a successful build of the repo._

_Note_:

* Instructions below assume C:\corert is the repo root.
* Build the repo using build.cmd. Binaries are binplaced to ```<repo_root>\bin\Product\<OS>.<arch>.<Config>```

# Build ILCompiler #

Build your repo by issuing the following command at repo root:

> build[.cmd|.sh] clean [Debug|Release]

This will result in the following:

- Build native and managed components of ILCompiler
- Build tests
- Restore dependent nuget packages into
`<repo_root>\bin\Product\Windows_NT.x64.Debug\.nuget\publish1`, including the *Microsoft.DotNet.ILCompiler* and *Microsoft.DotNet.ILCompiler.SDK[.Debug]* package built
- Run tests

*Note: Currently, the tests are executed only for Windows Ubuntu/Mac OSX support is coming soon.*

# Compiling source to native code using the ILCompiler you built#

*Note: On Windows, please ensure you have VS 2015 installed to get the native toolset and work within a VS 2015 x64 Native Tools command prompt.*

* Ensure that you have done a repo build per the instructions above.
* Create a new folder and switch into it. 
* Issue the command, `dotnet init`, on the command/shell prompt. This will add a template source file and corresponding project.json. If you get an error, please ensure the [pre-requisites](prerequisites-for-building.md) are installed. 


## Using RyuJIT ##

**Note: Support for Mac OSX is coming soon!**

This approach uses the same code-generator (RyuJIT), as [CoreCLR](https://github.com/dotnet/coreclr), for compiling the application. From the shell/command prompt, issue the following commands, from the folder containing your source file and project.json, to generate the native executable

    dotnet restore
    dotnet compile --native --ilcpath bin\Product\Windows_NT.x64.Debug\.nuget\publish1

Native executable will be dropped in `./bin/[configuration]/[framework]/native/` folder and will have the same name as the folder in which your source file is present.

Linking is done using the platform specific linker. The RyuJIT compiler used is the one that came with the .NET CLI package you installed (as part of [pre-requisites](prerequisites-for-building.md)).

## Using CPP Code Generator ##

This approach uses platform specific C++ compiler and linker for compiling/linking the application. 

From the shell/command prompt, issue the following commands to generate the native executable:

    dotnet restore
    dotnet compile --native --cpp --ilcpath bin\Product\Windows_NT.x64.Debug\.nuget\publish1
