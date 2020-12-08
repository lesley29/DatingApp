docker image build -f ./build/docker/Back.Dockerfile -t dating-app/back:dev-docker ./src/back
docker image build -f ./build/docker/Front.Dockerfile -t dating-app/front:dev-docker ./src/front

docker-compose -f ./build/docker-compose/dev-docker.compose.yml -p dating_app run --rm start_dependencies
docker-compose -f ./build/docker-compose/dev-docker.compose.yml -p dating_app up -d --build app