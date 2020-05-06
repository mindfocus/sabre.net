<?php

// place your code here
namespace Sabre\Uri;

class UriFunctions {
	function resolve(string $basePath, string $newPath): string {
		return resolve($basePath, $newPath);
	}
	function parse(string $uri): array {
		return parse($uri);
	}
	function normalize(string $uri): string {
		return normalize($uri);
	}
	function build(array $parts): string {
		return build($parts);
	}
	function split(string $path): array {
		return split($path);
	}
	function _parse_fallback(string $uri): array {
		return _parse_fallback($uri);
	}
}