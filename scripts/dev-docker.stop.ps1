docker-compose -f ./build/docker-compose/dev-docker.compose.yml -p dating_app down -v
docker image rm -f dating-app/back:dev-docker dating-app/front:dev-docker dating-app:dev-docker