Fixed Width Record Library
==========================

This library provides tools for working with fixed width records.

License
-------

Released under a MIT license - http://www.opensource.org/licenses/mit-license.php 

Installation
------------

Latest version is built on MyGet from the latest branch here:

```
https://www.myget.org/feed/orangetentacle/package/OrangeTentacle.FixedWidth
```

A "stable" version is publically accessible on nuget:

```
Install-Package OrangeTentacle.FixedWidth
```


FixedWidthParser.Parse
----------------------

FixedWidthParser.Parse parses a fixed width record and populates properties on a 
target object decorated with the FixedWidthColumnAttribute.  Attempts are made to 
convert to target types.

### Usage

Decorate properties in target class with FixedWidthColumn.  Set the start and 
end values to the subset of the record this property applies to.  If delimited 
by a decimal point, set DecimalPoint to the number of places from the end.

```csharp
public class ComplexRecord
{
    [FixedWidthColumn(0, 10)]
    public string StringColumn { get; set; }

    [FixedWidthColumn(10, 20)]
    public int IntColumn { get; set; }

    [FixedWidthColumn(20, 30, DecimalPoint = 2)]
    public decimal DecColumn { get; set; }
}
```

Call FixedWidthParser.Parse with the type and the line to parse.

```csharp
var line = "This.     " + // String
           "0000000032" + // Int
           "      3212"; // Dec

var record = FixedWidthParser.Parse<ComplexRecord>(line);
```

Disclaimer
----------

Orange Tentacle accepts NO LIABILITY whatsoever, in any way, shape, or form, 
in this world of the next, for the stability of this library or for your 
financial health.  USE AT YOUR OWN RISK.
