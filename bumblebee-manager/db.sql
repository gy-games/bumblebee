/*
SQLyog v10.2
MySQL - 5.1.72-log : Database - db_bumblebee
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE=''NO_AUTO_VALUE_ON_ZERO'' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
/*Table structure for table `bumblebee_agent` */

CREATE TABLE `bumblebee_agent` (
  `agent_ip` VARCHAR(15) NOT NULL COMMENT ''AgentIP'',
  `agent_name` VARCHAR(40) NOT NULL COMMENT ''Agent名称'',
  `asset` VARCHAR(20) NOT NULL COMMENT ''资产号'',
  `manager` VARCHAR(20) DEFAULT NULL COMMENT ''负责人'',
  `main_name` VARCHAR(20) DEFAULT NULL COMMENT ''一级分类'',
  `sub_name` VARCHAR(20) DEFAULT NULL COMMENT ''二级分类'',
  PRIMARY KEY (`agent_ip`)
) ENGINE=INNODB DEFAULT CHARSET=utf8 COMMENT=''agent信息表'';

/*Table structure for table `bumblebee_group` */

CREATE TABLE `bumblebee_group` (
  `group_id` INT(11) NOT NULL AUTO_INCREMENT COMMENT ''分组ID'',
  `group_name` VARCHAR(40) NOT NULL COMMENT ''组名'',
  `create_time` DATETIME DEFAULT NULL COMMENT ''创建时间'',
  `create_user` VARCHAR(40) DEFAULT NULL COMMENT ''创建人'',
  `desc` VARCHAR(100) DEFAULT NULL COMMENT ''描述'',
  PRIMARY KEY (`group_id`)
) ENGINE=INNODB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8 COMMENT=''分组表'';

/*Table structure for table `bumblebee_user` */

CREATE TABLE `bumblebee_user` (
  `user_id` INT(11) NOT NULL AUTO_INCREMENT COMMENT ''主键ID'',
  `user_name` VARCHAR(40) NOT NULL COMMENT ''用户名'',
  `email` VARCHAR(40) NOT NULL COMMENT ''邮箱'',
  `pwd` VARCHAR(40) NOT NULL COMMENT ''密码'',
  `create_time` DATETIME DEFAULT NULL COMMENT ''创建时间'',
  `create_user` VARCHAR(40) DEFAULT NULL COMMENT ''创建人'',
  `last_login_time` DATETIME DEFAULT NULL COMMENT ''最后登录时间'',
  `group_id` INT(11) DEFAULT NULL COMMENT ''用户组Id'',
  `is_system` TINYINT(4) NOT NULL DEFAULT ''0'' COMMENT ''是否为系统管理员：0-不是，1-是'',
  PRIMARY KEY (`user_id`)
) ENGINE=INNODB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8 COMMENT=''用户表'';

/*Table structure for table `command_blacklist` */

CREATE TABLE `command_blacklist` (
  `id` INT(11) NOT NULL AUTO_INCREMENT COMMENT ''主键ID'',
  `command` VARCHAR(200) NOT NULL COMMENT ''命令'',
  PRIMARY KEY (`id`)
) ENGINE=INNODB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8 COMMENT=''命令黑名单'';

/*Table structure for table `group_permission` */

CREATE TABLE `group_permission` (
  `group_id` INT(11) NOT NULL COMMENT ''分组ID'',
  `main_name` VARCHAR(20) NOT NULL COMMENT ''机器一级分类'',
  PRIMARY KEY (`group_id`,`main_name`)
) ENGINE=INNODB DEFAULT CHARSET=utf8 COMMENT=''分组授权表'';

/*Table structure for table `operate_log` */

CREATE TABLE `operate_log` (
  `log_id` INT(11) NOT NULL AUTO_INCREMENT COMMENT ''日志ID'',
  `ip` VARCHAR(15) NOT NULL COMMENT ''操作的机器IP'',
  `param` VARCHAR(255) NOT NULL COMMENT ''参数'',
  `result` TEXT COMMENT ''返回结果'',
  `start_time` DATETIME DEFAULT NULL COMMENT ''开始时间'',
  `end_time` DATETIME DEFAULT NULL COMMENT ''结束时间'',
  `cost_time` INT(11) DEFAULT NULL COMMENT ''耗时（毫秒ms）'',
  `operate_user` VARCHAR(40) DEFAULT NULL COMMENT ''操作人'',
  PRIMARY KEY (`log_id`)
) ENGINE=INNODB AUTO_INCREMENT=1575 DEFAULT CHARSET=utf8 COMMENT=''操作日志表'';


INSERT  INTO `bumblebee_user`(`user_id`,`user_name`,`email`,`pwd`,`create_time`,`create_user`,`last_login_time`,`group_id`,`is_system`) VALUES (1,''超级管理员'',''admin@gyyx.cn'',''E10ADC3949BA59ABBE56E057F20F883E'',NOW(),''超级管理员'',NULL,NULL,1);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
