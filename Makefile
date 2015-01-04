BIN = ./bin
MCS ?= mcs -sdk:4 -platform:anycpu -warnaserror+ -define:RELEASE
XWTDLLS = ../../Components/xwt

SOURCES = \
	AssemblyInfo.cs \
	MainClass.cs \
	MainWindow.cs \
	Multiplication.cs \
	MultiplicationFactory.cs \
	PdfCreator.cs \
	Setup.cs

RESOURCES = \
	-res:Worksheet.pdf

REFERENCES = \
	-r:$(BIN)/Xwt.dll

KEYFILE = \
	MultiplicationTableGenerator.key

all:
	test -d $(BIN) || mkdir $(BIN)
	cp $(XWTDLLS)/* $(BIN)
	$(MCS) -target:winexe -out:$(BIN)/MultiplicationTableGenerator.exe $(SOURCES) -keyfile:$(KEYFILE) $(REFERENCES) $(RESOURCES)
	
clean:
	rm -f -R $(BIN)
