# KTOP
Kindle Text Optimizer for Persian eBooks.


## What is KTOP? What does it do?
KTOP is a tool for making Persian eBooks ( EPUBs for now ) compatible to E-Readers such as Kindle. By releasing [KF8](https://www.amazon.com/gp/feature.html?docId=1000729511) by Amazon, Kindle devices are be able to display right-to-left Persian and Arabic books. Unfortunately the default font of Kindle is not really good and it has also several drawbacks.

**Default Font:**


![Default Font](https://al1b.github.io/KTOP/kindle-default-font.jpg) 

Books can be published with embedded fonts but Amazon Kindle won't display Persian and Arabic eBooks properly with embedded fonts and It will display characters separated.


![separated letters](https://al1b.github.io/KTOP/kindle-seperated-persian-text.jpg) 

By using *KTOP* you can optimize your eBooks to display properly and nicely on Kindle e-Ink devices.

**Optimized version:**

![separated letters](https://al1b.github.io/KTOP/kindle-persian-text-optmized.jpg) 


## Sample outputs

| Default font        | Custom font           | Optimized by ***KTOP*** - Custom font  |
| :-------------: |:-------------:| :-----:|
|![Default font](https://al1b.github.io/KTOP/02-default-font.jpg)|![Custom font](https://al1b.github.io/KTOP/03-custom-font.jpg)|![Optimized font](https://al1b.github.io/KTOP/01-optimized.jpg)|


## How to use

KTOP has a command line interface at the moment which is really easy to use.

```
Usage: ktop [options]

Options:
  -i|--input               (Required)The path of input file.
  -o|--output              (Optional)Path of output file.
  -r|--overwrite           Overwrite the output file if output file already exists
  -f|--fix-arabic-yeh-kaf  Replace all Arabic Yeh and Kaf with Persian ones.    
  -n|--no-optimize         Will not optmize the eBook.  
  -?|-h|--help             Show help information
```

Example:


```
Windows:
KTOP -i "d:/my-books/programming/csharp.epub"
KTOP -input "./csharp.epub" -output "opt-csharp.epub"

Linux and Mac:
./KTOP.CLI -i "./csharp.epub"
```


## Requirements

*KTOP* is written in Microsoft C# and [.NET Core](https://github.com/dotnet/core) and it can be run on Linux, Mac OSX and Microsoft Windows. If you are on Linux or Mac need to install .NET Core on you PC.

***Linux:***
Depend on what distro you are using you need to install .NET Core runtime.

1. [.NET Core Ubuntu 14.04, 16.04 & Linux Mint 17](http://www.microsoft.com/net/core#ubuntu)
2. [.NET Core Debian 8](http://www.microsoft.com/net/core#debian)
3. [.NET Core Fedora 23](http://www.microsoft.com/net/core#fedora)
4. [.NET Core CentOS 7.1 & Oracle Linux 7.1](http://www.microsoft.com/net/core#centos)
5. [.NET Core openSUSE 13.2](http://www.microsoft.com/net/core#opensuse)

***Mac OS X:***
[.NET Core For Mac OS X 10.11](http://www.microsoft.com/net/core#macos)


## Download and Install
| Operating System       | Binary Release          | Size (MB)|Type         |
| :------------- |:-------------|:-------------|:-------------|
|Microsoft Windows 7, 8, 8.1, 10|[KTOP.1.6.1b.exe](https://github.com/al1b/KTOP/releases/download/v1.5.1b/KTOP.1.5.1b.exe)|14.8|Setup Installer|
|Debian 8|[KTOP.1.5.1b-debian8-x64.tar.gz](https://github.com/al1b/KTOP/releases/download/v1.5.1b/KTOP.1.5.1b-debian.8-x64.tar.gz)|18.7| tar.gz archive|
|Ubuntu 14.04|[KTOP.1.5.1b-ubuntu.14.04-x64.tar.gz](https://github.com/al1b/KTOP/releases/download/v1.5.1b/KTOP.1.5.1b-ubuntu.14.04-x64.tar.gz)|18.6| tar.gz archive|
|Ubuntu 16.04|[KTOP.1.5.1b-ubuntu.16.04-x64.tar.gz](https://github.com/al1b/KTOP/releases/download/v1.5.1b/KTOP.1.5.1b-ubuntu.16.04-x64.tar.gz)|18.6| tar.gz archive|
|Mac OSX 10.10|[MacOSX10.10-x64.zip](https://github.com/al1b/KTOP/releases/download/v1.5.1b/KTOP.1.5.1b-osx.10.10-x64.zip)|18.1| zip archive|



## Change Logs
---

***Sep 22, 2016 - v1.6.0b***
1. Command line interface is completely refactored!
2. A new option has added to CLI, you are now be able to define output path.
3. Some minor and major bugs fixed.

***Sep 10, 2016 - v1.5.1bb***
1. Some minor bugs fixed

***Sep 09, 2016 - v1.5.0b***
1. Made Command line interface simpler
2. KTOP now supports Linux, Mac and Windows

***Aug 12, 2016 - 1.0.0b***
1. Release the first version

***

## Build and run the source code

https://github.com/al1b/KTOP/wiki/Build-and-Debug-the-source


## Roadmap


1. Support `azw3` and `mobi` formats.
2. Graphical User Interface rather than CLI
3. ~~Compatibility with Mono or .NET Core ( be able to run on Linux or Mac )~~ It's now cross-platform.
4. Create repo-package for other Operating Systems.
