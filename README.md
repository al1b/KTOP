# KTOP
Kindle Text Optimizer for Persian eBooks.

## What is KTOP? What does it do?

*KTOP* is a tool for increasing the readability of Persian and Arabic eBooks on Amazon Kindle. By releasing [KF8](https://www.amazon.com/gp/feature.html?docId=1000729511) by Amazon, Kindle devices are be able to display right-to-left Persian and Arabic books. Unfortunately the default font of Kindle is not really good and it has also several drawbacks.

**Default Font:**


![Default Font](https://al1b.github.io/KTOP/kindle-default-font.jpg) 

Users and publishers can ship/embedded custom fonts into their `epub`, `mobi` and `azw3` eBook files. Amazon Kindle doesn't display Persian and Arabic eBooks properly with custom fonts. It will display letters separated.


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

It has 3 options:

| Option       | Description          |
| :------------- |:-------------|
|/a|Replace any Arabic Keh and Yeh with Persian Yeh and Keh letters.|
|/cs|Correct spelling mistakes and typos ( only for Persian eBooks ).|
|/p|Convert Persian/Arabic letters into single unicode character.|

Example:

```
KTOP.CLI.exe "d:\my-books\programming\csharp.epub" /a /p /cs
```


Notes:

1. For Arabic eBooks just use `/cs` option.
2. For Persian eBooks it is recommended to use all options above.
3. `/cs` Option might takes several minutes, so be patient.
4. By using `/cs` option you will get a log file of what *KTOP* corrected on your eBook.
5. *KTOP* won't replace and save changes on the original file, it will create another file next to the original one.

## Requirements

*KTOP* is written in Microsoft C# and it needs NetFramework 4.5 to be run on your Windows. You can download NetFramework from Microsoft.

1. [NetFramework 4.6.1](https://www.microsoft.com/en-us/download/details.aspx?id=49982)
2. [NetFramework 4.5](https://www.microsoft.com/en-us/download/details.aspx?id=42642)


## Roadmap


1. Support `awz3` and `mobi` formats.
2. Graphical User Interface rather than CLI
3. Compatibility with Mono or DOTNet Core ( be able to run on Linux or Mac )


