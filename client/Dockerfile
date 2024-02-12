FROM node:alpine

WORKDIR /usr/src/app
EXPOSE 4200
EXPOSE 4201

COPY . /usr/src/app

RUN npm install -g @angular/cli

RUN npm install

CMD ["ng", "serve", "--host", "0.0.0.0"]