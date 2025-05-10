#!/usr/bin/env bash

set -euo pipefail
wd=$(dirname "$0")

# build std lib
cd /home/ian/f/myrepos/fable.nostd/src/fable.nostd.core
dotnet build -c Release

cd /home/ian/f/myrepos/fable.nostd/src/fable.nostd.tests/
dotnet run --project /home/ian/f/myrepos/fable.nostd/src/fable-nostd/fable-nostd.fsproj -c Debug --no-restore -- fable.nostd.tests.fsproj --noCache