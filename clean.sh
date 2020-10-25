#!/bin/sh

if [ $# -eq 0 ]
then
    find ./lib/ -type f -name '*.dll' -delete
else
    while [ $# -ne 0 ]
    do
        ARG="$1"
        shift
        case "$ARG" in
        all)
            find ./bin/ -type f -name '*.exe' -delete
            find ./lib/ -type f -name '*.dll' -delete
            ;;
        esac
    done  
fi
