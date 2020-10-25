#!/bin/sh

mcs /target:library /out:./lib/corestructs.dll ./src/*.cs
mcs -r:./lib/corestructs.dll /out:./bin/corestructstests.exe ./test/*.cs

BASHRC="/home/${USER}/.bashrc"
MONODIR="/usr/lib/mono-custom-libs/"

echo "Build initialise"

if grep -q "export MONO_PATH=${MONODIR}" "$BASHRC"; then
    echo "MONO_PATH export statement found in ${BASHRC}"
else
    echo "Appending MONO_PATH export statement to ${BASHRC}"
    echo "\nexport MONO_PATH=${MONODIR}" >> "$BASHRC"
    echo "MONO_PATH export statement appended to ${BASHRC}"
fi

. "$BASHRC"

if [ -d "$MONODIR" ]; then
    echo "${MONODIR} available"
else
    echo "Creating ${MONODIR}"
    sudo mkdir "$MONODIR"
    echo "${MONODIR} created"
fi

echo "Copying dll to MONO_PATH"
sudo cp ./lib/corestructs.dll "$MONODIR"
echo "Dll copy complete"

echo "Build complete"
