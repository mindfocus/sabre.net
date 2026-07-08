<?php


namespace Sabre\DAVACL\Exception;

use Sabre\DAV;

/**
 * NeedPrivileges.
 *
 * The 403-need privileges is thrown when a user didn't have the appropriate
 * permissions to perform an operation
 *
 * @copyright Copyright (C) fruux GmbH (https://fruux.com/)
 * @author Evert Pot (http://evertpot.com/)
 * @license http://sabre.io/license/ Modified BSD License
 */
class NeedPrivileges extends DAV\Exception\Forbidden
{
    /**
     * The relevant uri.
     *
     * @var string
     */
    protected $uri;

    /**
     * The privileges the user didn't have.
     *
     * @var array
     */
    protected $privileges;

    /**
     * Constructor.
     *
     * @param string $uri
     */
    public function __construct($uri, array $privileges)
    {
        $this->uri = $uri;
        $this->privileges = $privileges;

        parent::__construct('User did not have the required privileges ('.implode(',', $privileges).') for path "'.$uri.'"');
    }

    /**
     * Adds in extra information in the xml response.
     *
     * This method adds the {DAV:}need-privileges element as defined in rfc3744
     */
    public function serialize(DAV\Server $server, \Sabre\Xml\Writer $writer)
    {
        $writer->startElement('{DAV:}need-privileges');

        foreach ($this->privileges as $privilege) {
            preg_match('/^{([^}]*)}(.*)$/', $privilege, $privilegeParts);
            $writer->writeElement('{DAV:}resource', [
                '{DAV:}href' => $server->getBaseUri().$this->uri,
                '{DAV:}privilege' => [
                    '{'.$privilegeParts[1].'}'.$privilegeParts[2] => null,
                ],
            ]);
        }

        $writer->endElement();
    }
}
