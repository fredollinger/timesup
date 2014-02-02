APP=winforms
win:
	gmcs $(APP).cs -pkg:dotnet

install:
	mkdir -p $(DESTDIR)/usr/bin
	cp $(APP).exe $(DESTDIR)/usr/bin

clean:
	rm -f $(APP).exe


