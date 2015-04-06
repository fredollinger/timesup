APP=timesup
CSHARP=gmcs
#CSHARP=dmcs

FLAGS = -pkg:appindicator-sharp-0.1 -pkg:dotnet

timesup.exe: 
	$(CSHARP) $(FLAGS) timesup.cs timerobj.cs timerpopup.cs indicator.cs

install:
	mkdir -p $(DESTDIR)/usr/bin
	cp $(APP).exe $(DESTDIR)/usr/bin

clean:
	rm -f $(APP).exe poptest.exe

poptest: 
	$(CSHARP) -pkg:dotnet poptest.cs timerobj.cs timerpopup.cs
	./poptest.exe

test: timesup.exe
	mono --runtime=v4.0 timesup.exe 
