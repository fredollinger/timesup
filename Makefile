APP=timesup

win: clean
	gmcs -pkg:dotnet timesup.cs timerobj.cs 

install:
	mkdir -p $(DESTDIR)/usr/bin
	cp $(APP).exe $(DESTDIR)/usr/bin

clean:
	rm -f $(APP).exe poptest.exe

poptest: 
	gmcs -pkg:dotnet poptest.cs timerobj.cs 
	./poptest.exe
