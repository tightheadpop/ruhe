# SslRedirectModule #

Add this module to your list of http modules in web.config to force all requests to your application to be 301 redirected to their https equivilant.

For example:

```
http://localhost/ -> https://localhost/
http://localhost/About -> https://localhost/About
```

# Configuration #

```
<configuration>
...
<system.web>
  ...
  <httpModules>
    ...
    <add name="SslRedirectModule" type="Ruhe.Web.SslRedirectModule"/>
    ...
  </httpModules>
  ...
</system.web>
...
</configuration>
```