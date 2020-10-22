docker run `
    --rm `
    --name dating-app-postgres `
    -e POSTGRES_USER=dating_app_user `
    -e POSTGRES_PASSWORD=dating_app_password `
    -e POSTGRES_DB=dating_app `
    -v ${PWD}/infra-data/postgres:/var/lib/postgresql/data `
    -p 7432:5432 `
    -d `
    postgres:13-alpine