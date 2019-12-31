require 'rake/clean'

REPO="/var/www/repo/dists/precise/universe/binary-amd64"

APP="timesup"
MAJOR_VERSION="0"
MINOR_VERSION="0"
MICRO_VERSION="2"
UBUNTU_VERSION="1"
WHOLE_VERSION=MAJOR_VERSION + "." + MINOR_VERSION + "." + MICRO_VERSION 
DEBIAN_VERSION=MAJOR_VERSION + "." + MINOR_VERSION + "." + MICRO_VERSION + "-" + UBUNTU_VERSION 
#APP_DIR="ktomgirl" + "-" + WHOLE_VERSION
BUILD='builddir'
#CMAKE="cmake ../src"
TARBALL="#{APP}_#{DEBIAN_VERSION}.orig.tar.xv"
LINKPATH="#{APP}-#{WHOLE_VERSION}"

CLEAN.include("*.deb", "*.changes", "*.dsc", "#{APP}_#{DEBIAN_VERSION}.debian.tar.gz", "src/obj-x86_64-linux-gnu", "builddir", "#{TARBALL}", "#{LINKPATH}", "#{APP}.exe")

directory 'builddir'

task :default => :ui 

desc "build it"
task :build => :ui do
end

desc "build it"
task :ui => 'builddir' do
	sh "make 2>err"
end

desc "build debian package"
task :deb => [:clean, :orig] do
	sh "debuild -i -us -uc -b"
end

desc "build debian package"
task :orig do
  cd ".."
  sh "pwd"
	sh "rm -f #{LINKPATH} #{TARBALL}"
	sh "ln -s #{APP} #{LINKPATH}"
	sh "tar --exclude debian -chJvf #{TARBALL} #{LINKPATH}"
	cd "#{APP}"
end

desc "build debian package"
task :install do
   sh "sudo cp timesup.exe timesup /usr/bin"
end

# Mon 30 Dec 2019 03:59:56 PM PST
