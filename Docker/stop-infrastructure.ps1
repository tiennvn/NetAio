$currentFolder = $PSScriptRoot

docker-compose -f $currentFolder/docker-compose.infrastructure.yml -p docker-infrastructure down --remove-orphans