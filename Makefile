APP=timesup
#CSHARP=mono-csc
CSHARP=mcs

FLAGS = -pkg:appindicator-sharp-0.1 -pkg:dotnet

win: clean
	gmcs $(FLAGS) timesup.cs timerobj.cs timerpopup.cs indicator.cs

install:
	mkdir -p $(DESTDIR)/usr/bin
	cp $(APP).exe $(DESTDIR)/usr/bin

clean:
	rm -f $(APP).exe poptest.exe

poptest: 
	gmcs -pkg:dotnet poptest.cs timerobj.cs timerpopup.cs
	./poptest.exe
test:
	mono --runtime=v4.0 timesup.exe 
