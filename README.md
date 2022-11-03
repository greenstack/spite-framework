# Spite Framework
[![.NET](https://github.com/greenstack/spite-framework/actions/workflows/dotnet.yml/badge.svg)](https://github.com/greenstack/spite-framework/actions/workflows/dotnet.yml)
[![.NET Framework](https://github.com/greenstack/spite-framework/actions/workflows/NETFramework.yml/badge.svg)](https://github.com/greenstack/spite-framework/actions/workflows/NETFramework.yml)

The Spite Framework is a C# library meant to simplify designing and
implementing turn-based gameplay. The hope is that through the Spite Framework,
developers can quickly develop all  kinds of turn-based games, from RPGs to
board games. To do this, Spite is centered on a few core design pillars:
 - Spite represents the model. The view and the controller are the game
 developer's responsibility.
 - Developers should be able to access and mess with the underlying structure
 should they need to.
 - Be compatible with as many C# game engines and frameworks as possible while
 also being as portable as possible.

Examples can be found in the [Spite Framework Examples](https://github.com/greenstack/spite-framework-examples) repository.

## Installation
How you integrate Spite to your project will depend on what technology you're using.

If you clone Spite into your project, you can set your branch to be whichever version of the framework you like. For the most up-to-date version, use the active `-dev` branch.

### Visual Studio/Dotnet
If you're using Visual Studio/dotnet, you will need to clone the repo [as a git submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules)
then [add a reference to Spite](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-reference).

### Using Unity
In order to use Spite with Unity, you'll need to include it as a [package](https://docs.unity3d.com/Manual/PackagesList.html).

The recommended method of including Spite is by by cloning the repo to the 
`Packages` folder of your Unity project. If you're using git as your version
control, you can do this by cloning it [as a git submodule](https://git-scm.com/book/en/v2/Git-Tools-Submodules).

You can also use Unity's package manager to include Spite from another location
on your computer:
1. [From a local folder](https://docs.unity3d.com/Manual/upm-ui-local.html).
2. [From a local tarball file](https://docs.unity3d.com/Manual/upm-ui-tarball.html)
These methods aren't recommended because it may cause problems when using a VCS.

Because we don't want Unity's `.meta` files to be included in other projects that
use Spite, those are ignored, making including Spite through Unity's package manager
as a git repo is, unfortunately, currently impossible.

If you don't intend to use Unity's Package manager (which is the recommended route),
you can also [build the Spite DLL](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build) and include it into your project.
