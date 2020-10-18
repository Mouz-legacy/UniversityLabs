#!/bin/sh

set -e -u

D=$(dirname "$0")
dotnet exec --runtimeconfig "$D/dupfinder.unix.runtimeconfig.json" "$D/dupfinder.exe" "$@"