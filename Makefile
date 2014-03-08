APP=timesup

win:
	gmcs -pkg:dotnet *.cs

install:
	mkdir -p $(DESTDIR)/usr/bin
	cp $(APP).exe $(DESTDIR)/usr/bin

clean:
	rm -f $(APP).exe


