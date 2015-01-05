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
	convert ./Icons/Icon16.png ./Icons/Icon32.png ./Icons/Icon64.png ./Icons/Icon128.png ./Icons/Icon256.png -colors 256 $(BIN)/MultiplicationTableGenerator.ico
	$(MCS) -target:winexe -out:$(BIN)/MultiplicationTableGenerator.exe $(SOURCES) -keyfile:$(KEYFILE) $(REFERENCES) $(RESOURCES) -win32icon:$(BIN)/MultiplicationTableGenerator.ico
	
clean:
	rm -f -R $(BIN)
