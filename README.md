# JsonToTableConverter

A simple console application built to convert JSON file of item structure ([example](./app/JsonToTable/Sample.json)) into different table format.

At the moment, the following output formats are supported
1. Markdown `.md`
1. Comma-separated file `.csv`
## Prerequisite
1. .NET 5.0 Runtime
1. Visual Studio IDE

## Command usage

To generate markdown as output, use `.md` extension. Example: ([output.md](./result/output.md))
```
./JsonToTable.exe Sample.json ./result/output.md
```

To generate comma-separated value, use `.csv` extension. Example: ([output.csv](./result/output.csv))
```
./JsonToTable.exe Sample.json ./result/output.csv
```

