#!/usr/bin/env bash

set -euo pipefail
wd=$(dirname "$0")

cd /home/ian/f/myrepos/fable.nostd/src/fable.nostd.tests/
dotnet run --project /home/ian/f/myrepos/fable.nostd/src/fable-nostd/fable-nostd.fsproj -c Debug --no-restore -- watch fable.nostd.tests.fsproj --noCache