FROM node:12-alpine

WORKDIR /src

COPY ./package.json .
COPY ./package-lock.json ./

RUN npm ci

COPY ./ .

RUN npm run build:prod

ENTRYPOINT []