APP=timesup

win: clean
	gmcs -pkg:dotnet timesup.cs timerobj.cs timerpopup.cs

install:
	mkdir -p $(DESTDIR)/usr/bin
	cp $(APP).exe $(DESTDIR)/usr/bin

clean:
	rm -f $(APP).exe poptest.exe

poptest: 
	gmcs -pkg:dotnet poptest.cs timerobj.cs timerpopup.cs
	./poptest.exe
