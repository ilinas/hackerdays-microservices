#!/usr/bin/env bash

HOSTS_LINE=`cat /etc/hosts | grep ${HOSTNAME}`
EXT_IP=`(echo ${HOSTS_LINE} | grep -o '[0-9]\+[.][0-9]\+[.][0-9]\+[.][0-9]\+')`

eventstored --ext-ip ${EXT_IP} --int-ip ${EXT_IP} $@
