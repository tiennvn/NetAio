$currentFolder = $PSScriptRoot

docker network create app-network
docker-compose -f $currentFolder/docker-compose.infrastructure.yml -p docker-infrastructure up -d --remove-orphans